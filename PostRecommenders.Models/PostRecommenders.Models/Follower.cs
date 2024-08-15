using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostRecommender.Contracts;

namespace PostRecommenders.Models;

public class Follower
{
    public string PageAddress { get; }
    public string Title { get; }
    public HashSet<string> InterestedHashtags { get; } = [];
    public HashSet<PageType> InterestedType { get; } = [];


    public Follower(string pageAddress, string title)
    {
        PageAddress = pageAddress;
        Title = title;
    }
}