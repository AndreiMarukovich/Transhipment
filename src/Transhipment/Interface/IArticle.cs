namespace Transhipment
{
	public interface IArticle : ICreativeWork
	{
        /// <summary>
        /// The actual body of the article.
        /// </summary>
        string ArticleBody { get; set; }
        /// <summary>
        /// Articles may belong to one or more 'sections' in a magazine or newspaper, such as Sports, Lifestyle, etc.
        /// </summary>
        string ArticleSection { get; set; }
        /// <summary>
        /// The number of words in the text of the Article.
        /// </summary>
        int WordCount { get; set; }
	}
}