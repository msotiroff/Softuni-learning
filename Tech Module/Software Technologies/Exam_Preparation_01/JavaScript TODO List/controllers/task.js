const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        //TODO: Implement me...

		Task.find().then(tasks => {
            res.render('task/index', {'tasks': tasks});
		})
    },
	createGet: (req, res) => {
        //TODO: Implement me...

		return res.render('task/create')
	},
	createPost: (req, res) => {
        //TODO: Implement me...

		let taskParameters = req.body;

		if (taskParameters.title === undefined || taskParameters.comments === undefined) {
			res.redirect('/');
			return;
		}

        if (taskParameters.title === "" || taskParameters.comments === "") {
            res.redirect('/');
            return;
        }

		Task.create(taskParameters).then(task => {
			res.redirect('/');
		})
	},
	deleteGet: (req, res) => {
        //TODO: Implement me...

		let id = req.params.id;

		Task.findById(id).then(task => {
			if (!task) {
				res.redirect('/');
				return;
			}

			res.render('task/delete', task)
		})
	},
	deletePost: (req, res) => {
        //TODO: Implement me...
        let id = req.params.id;

        Task.findByIdAndRemove(id).then((task => {
        	res.redirect('/');
		}))

    }
};