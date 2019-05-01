const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {

        Film.find().then(allFilms => {
            res.render('film/index', {'films': allFilms});
        })
	},
	createGet: (req, res) => {

        return res.render('film/create')
	},
	createPost: (req, res) => {

        let filmParameters = req.body;

        if (filmParameters.name === undefined
			|| filmParameters.genre === undefined
			|| filmParameters.director === undefined
			|| filmParameters.year === undefined) {
            res.redirect('/');
            return;
        }

        if (filmParameters.name === ""
			|| filmParameters.genre === ""
			|| filmParameters.director === "") {
            res.redirect('/');
            return;
        }

        Film.create(filmParameters).then(task => {
            res.redirect('/');
        })
	},
	editGet: (req, res) => {

        let id = req.params.id;

        Film.findById(id).then(filmToEdit => {
            if (!filmToEdit) {
                res.redirect('/');
                return;
            }

            res.render('film/edit', filmToEdit)
        })
	},
	editPost: (req, res) => {

        let filmId = req.params.id;

        let filmToEdit = req.body;

        if (filmToEdit.name === undefined
			|| filmToEdit.genre === ""
			|| filmToEdit.director === ""
			|| filmToEdit.year === "") {
            res.redirect('/');
            return;
        }

        Film.findByIdAndUpdate(filmId, filmToEdit).then(film => {
            res.redirect("/");
        })
	},
	deleteGet: (req, res) => {

        let id = req.params.id;

        Film.findById(id).then(filmToDelete => {
            if (!filmToDelete) {
                res.redirect('/');
                return;
            }

            res.render('film/delete', filmToDelete)
        })
	},
	deletePost: (req, res) => {

        let id = req.params.id;

        Film.findByIdAndRemove(id).then((filmToDelete => {
            res.redirect('/');
        }))
	}
};