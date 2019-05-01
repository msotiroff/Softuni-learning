const Product = require('../models/Product');

module.exports = {
    index: (req, res) => {
        Product.find().then(allProducts => {
            res.render('product/index', {'entries': allProducts});
        })
    },
    createGet: (req, res) => {
        return res.render('product/create')
    },
    createPost: (req, res) => {
        let productParameters = req.body;

        if (productParameters.name === undefined
            || productParameters.priority === undefined
            || productParameters.quantity === undefined
            || productParameters.status === undefined) {
            res.redirect('/');
            return;
        }

        if (productParameters.name === ""
            || productParameters.status === ""
            || productParameters.priority === ""
            || productParameters.quantity === ""
            || productParameters.quantity <= 0) {
            res.redirect('/');
            return;
        }

        Product.create(productParameters).then(product => {
            res.redirect('/');
        }).catch(err => res.redirect('/'))
    },
    editGet: (req, res) => {
        let id = req.params.id;

        Product.findById(id).then(productToEdit => {
            if (!productToEdit) {
                res.redirect('/');
                return;
            }

            res.render('product/edit', productToEdit)
        })
    },
    editPost: (req, res) => {
        let productId = req.params.id;

        let productToEdit = req.body;

        if (productToEdit.name === undefined
            || productToEdit.priority === undefined
            || productToEdit.quantity === undefined
            || productToEdit.status === undefined) {
            res.redirect('/');
            return;
        }

        if (productToEdit.name === ""
            || productToEdit.status === ""
            || productToEdit.priority === ""
            || productToEdit.quantity === ""
            || productToEdit.quantity <= 0) {
            res.redirect('/');
            return;
        }

        Product.findByIdAndUpdate(productId, productToEdit).then(product => {
            res.redirect("/");
        })
    }
};