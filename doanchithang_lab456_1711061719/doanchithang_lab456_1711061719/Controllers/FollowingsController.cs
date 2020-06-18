﻿using doanchithang_lab456_1711061719.DTOs;
using doanchithang_lab456_1711061719.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace doanchithang_lab456_1711061719.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };



            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            following = _dbContext.Followings
                .Where(x => x.FolloweeId == followingDto.FolloweeId && x.FollowerId == userId)
                .Include(x => x.Followee)
                .Include(x => x.Follower).SingleOrDefault();

            var followingNotification = new FollowingNotification()
            {
                Id = 0,
                Logger = following.Follower.Name + " following " + following.Followee.Name
            };
            _dbContext.FollowingNotifications.Add(followingNotification);
            _dbContext.SaveChanges();


            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult UnFollow(string followeeId, string followerId)
        {
            var follow = _dbContext.Followings
                .Where(x => x.FolloweeId == followeeId && x.FollowerId == followerId)
                .Include(x => x.Followee)
                .Include(x => x.Follower).SingleOrDefault();

            var followingNotification = new FollowingNotification()
            {
                Id = 0,
                Logger = follow.Follower.Name + " unfollow " + follow.Followee.Name
            };

            _dbContext.FollowingNotifications.Add(followingNotification);

            _dbContext.Followings.Remove(follow);
            _dbContext.SaveChanges();
            return Ok();
        }
        //private readonly ApplicationDbContext _dbContext;

        //public FollowingsController()
        //{
        //    _dbContext = new ApplicationDbContext();
        //}

        //[HttpPost]
        //public IHttpActionResult Attend(FollowingDto followingDto)
        //{

        //    var userId = User.Identity.GetUserId();
        //    if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
        //        return BadRequest("The Attendaces already exits!");
        //    var folowing = new Following
        //    {
        //        FollowerId = userId,
        //        FolloweeId = followingDto.FolloweeId

        //    };

        //    _dbContext.Followings.Add(folowing);
        //    _dbContext.SaveChanges();

        //    return Ok();
        //}
    }
}
