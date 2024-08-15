using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostRecommenders.Models;

public class Recommendation
{
    public Post Post { get; }
    public Follower Follower { get; }
    public Recommendation(Post post, Follower follower)
    {
        Post = post;
        Follower = follower;
    }
}