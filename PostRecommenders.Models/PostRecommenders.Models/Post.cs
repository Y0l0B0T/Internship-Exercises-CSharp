using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostRecommenders.Models;

public class Post
{
    public string PostAddress { get; }
    public int LikeCount { get; set; }
    public List<string> Hashtags { get; set; }

    public Post(string postAddress, int likeCount, List<string> hashtags)
    {
        PostAddress = postAddress;
        LikeCount = likeCount;
        Hashtags = hashtags;
    }
}