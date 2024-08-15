using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostRecommender.Contracts;

namespace PostRecommenders.Models;

public class CustomerPage
{
    public string Title { get; }
    public PageType PageType { get; }
    public int FollowerCount { get; set; }
    public decimal Wallet { get; set; }
    public List<Post> Posts { get; set; } = [];


    public CustomerPage(string title, PageType pagetype, int followercount, decimal wallet = 1000)
    {
        Title = title;
        PageType = pagetype;
        FollowerCount = followercount;
        Wallet = wallet;
    }
}