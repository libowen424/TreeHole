namespace Homework1.models
{
    public class Subreply
    {
        public long Id { get; set; }
        public string PubName { set; get; }
        //发布者匿名
        public string RepName { get; set; }
        //向哪个匿名发布
        public string Content{ get; set; }
        //针对的回复内容
        public long ReplyId { get; set; }
    }
}
