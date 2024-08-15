using System.Data.Common;
using System.Numerics;
using PostRecommender.Contracts;

namespace PostRecommenders.Models;

public class InstagramService : IInstagramPageService
{
    private readonly List<CustomerPage> _customerPages = [];
    private readonly List<Follower> _Followers = [];
    private readonly List<Recommendation> _recommendations = [];

    private decimal TotalIncomee;

    public void RechargeCustomerWallet(WalletRechargeDto walletRechargeDto)// again
    {
        _customerPages[walletRechargeDto.CustomerId - 1].Wallet += walletRechargeDto.Amount;
    }

    public void RecommendCustomerPosts(RecommendCustomerPostsDto recommendCustomerPostsDto)
    {
        var customer = _customerPages[recommendCustomerPostsDto.CustomerId - 1];
        decimal PayPerRecommended = customer.PageType == PageType.Personal ? 10 : 100;
        _Followers.ForEach(follower =>
        {
            if (!follower.InterestedType.Contains(customer.PageType)) return;
            var posts = customer.Posts.Where(p => p.Hashtags.Any(c => follower.InterestedHashtags.Contains(c))).ToList();
            posts.ForEach(post =>
            {
                if (customer.Wallet >= PayPerRecommended)
                    _recommendations.Add(new Recommendation(post, follower));
            });
            customer.Wallet -= PayPerRecommended;
            TotalIncomee += PayPerRecommended;
        });
    }

    public void RegisterCustomerPage(RegisterCustomerPageDto registerCustomerPageDto)
    {
        if (registerCustomerPageDto.FollowerCount < 10)
        {
            throw new Exception("Need 10 Followers!!");
        }
        _customerPages.Add(new CustomerPage
        (
            registerCustomerPageDto.Title,
            registerCustomerPageDto.PageType,
            registerCustomerPageDto.FollowerCount));
    }

    public void RegisterCustomerPost(RegisterCustomerPostDto registerCustomerPostDto)
    {
        if (registerCustomerPostDto.LikeCount >= 5 && registerCustomerPostDto.Hashtags.Count >= 1)
            _customerPages[registerCustomerPostDto.CustomerId - 1].Posts.Add
            (new Post
            (
                registerCustomerPostDto.PostAddress,
                registerCustomerPostDto.LikeCount,
                registerCustomerPostDto.Hashtags
            ));
    }

    public void RegisterFollower(RegisterFollowerDto registerFollowerDto)
    {
        _Followers.Add(new Follower
        (
            registerFollowerDto.PageAddress,
            registerFollowerDto.Title
        ));
    }

    public void RegisterFollowerLikedPost(RegisterFollowerLikedPostDto registerFollowerLikedPostDto)
    {
        var follower = _Followers[registerFollowerLikedPostDto.FollowerId - 1];
        registerFollowerLikedPostDto.PostHashtags.ForEach(post => follower.InterestedHashtags.Add(post));
        follower.InterestedType.Add(registerFollowerLikedPostDto.LikedPageType);
    }

    public List<RecommendationDto> ShowCustomerRecommendations(RecommendationRequestDto recommendationRequestDto)
    {
        var list = new List<RecommendationDto>();
        var customer = _customerPages[recommendationRequestDto.CustomerId - 1];
        decimal PayPerRecommended = customer.PageType == PageType.Business ? 30 : 300;
        if (customer.Wallet >= PayPerRecommended)
        {
            var recommends = _Followers.SelectMany(_ => _.InterestedHashtags).GroupBy(_ => _).Select(_ => new
            {
                InterestedHashtag = _.Key,
                Count = _.Count()

            }).OrderByDescending(_ => _.Count).Select(_ => _.InterestedHashtag).ToList();

            list.Add(new RecommendationDto { Hashtags = recommends });
        }
        return list;
    }

    public List<ShowCustomerPageDto> ShowCustomersPage()
    {
        return _customerPages.Select((customerpage, index) => new ShowCustomerPageDto
        {
            Id = index + 1,
            FollowerCount = customerpage.FollowerCount,
            PageType = customerpage.PageType,
            Title = customerpage.Title,
            WalletBalance = customerpage.Wallet

        }).ToList();
    }

    public List<ShowFollowerDto> ShowFollowers()
    {
        return _Followers.Select((follower, index) => new ShowFollowerDto
        {
            FollowerId = index + 1,
            Title = follower.Title,
            PageAddress = follower.PageAddress
        }).ToList();
    }

    public ShowTotalIncomeDto ShowTotalIncome()
    {
        return new ShowTotalIncomeDto
        {
            TotalIncome = TotalIncomee
        };
    }
    public void UpdateCustomerFollowerCount(UpdateFollowerCountDto updateFollowerCountDto)
    {
        _customerPages[updateFollowerCountDto.CustomerId - 1].FollowerCount = updateFollowerCountDto.NewFollowerCount;
    }
}
