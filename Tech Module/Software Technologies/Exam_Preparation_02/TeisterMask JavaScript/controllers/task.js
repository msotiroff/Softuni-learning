const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {
		// TODO: Implement me...

        Task.find().then(allTasks => {
        	res.render('task/index', {
        		  'openTasks': allTasks.filter(t => t.status === 'Open'),
				'inProgressTasks': allTasks.filter(t => t.status === 'In Progress'),
				'finishedTasks': allTasks.filter(t => t.status === 'Finished')
			})
		})
	},
	createGet: (req, res) => {
		// TODO: Implement me...

        return res.render('task/create')
	},
	createPost: (req, res) => {
		// TODO: Implement me...

        let taskParameters = req.body;

        if (taskParameters.title === undefined) {
            res.redirect('/');
            return;
        }

        if (taskParameters.title === "") {
            res.redirect('/');
            return;
        }

        Task.create(taskParameters).then(task => {
            res.redirect('/');
        })
	},
	editGet: (req, res) => {
		// TODO: Implement me...

        let id = req.params.id;

        Task.findById(id).then(task => {
            if (!task) {
                res.redirect('/');
                return;
            }

            res.render('task/edit', task)
        })
	},
	editPost: (req, res) => {
		// TODO: Implement me...

        let taskId = req.params.id;

        let taskToEdit = req.body;

        if (taskToEdit.title === undefined || taskToEdit.title === "") {
            res.redirect('/');
            return;
        }

        Task.findByIdAndUpdate(taskId, taskToEdit).then(tasks => {
        	res.redirect("/");
		})
	}
};