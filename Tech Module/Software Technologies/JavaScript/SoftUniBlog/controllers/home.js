const Article = require('mongoose').model('Article');

module.exports = {
  index: (req, res) => {
      Article.find({}).sort({date: 'descending'}).limit(6).populate('author').then(articles => {
          res.render('home/index', {articles: articles});
      })
  }
};                                        