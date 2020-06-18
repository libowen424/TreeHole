
using System;

namespace Homework1.models
{
    public class Topic
    {
        //这里没有设置主键什么的
        public long Id { get; set; }
        public long ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string TopicName { get; set; }
        public string Describe { get; set; }
        public DateTime Date { get; set; }
        public string Publisher { get; set; }
    }
}
