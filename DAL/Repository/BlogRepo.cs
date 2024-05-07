using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApplication.DAL.Contracts;
using BlogApplication.ViewModels.BlogViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;

namespace BlogApplication.DAL.Repository
{
    public class BlogRepo(ApplicationDbContext applicationDbContext) : IBlogRepo
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;

        public async Task<IEnumerable<BlogViewModel>>? GetBlog()
        {
            var result = await applicationDbContext.Blogs.Include(e => e.Author).AsNoTracking().ToListAsync();
            if (result != null)
            {
                var viewresult = result.Select(e => new BlogViewModel(
                
            ){
                Name = e.Name,
                AuthorName = e.Author.Name,
                Body = e.Body,
                dateTime = e.DateCreated
            });
            return viewresult;
            }
            return null!;
        }

        public async Task<BlogViewModel?> GetBlog(Guid id)
        {
            var result =  await applicationDbContext.Blogs.Include(e=> e.Author).FirstOrDefaultAsync(e=> e.ID == id);
            if(result != null){

            var viewreult = new BlogViewModel(){
                AuthorName = result.Author.Name,
                Body = result.Body,
                Name = result.Name,
                 dateTime = result.DateCreated
            };
            return viewreult;
            }
            return null;
        }
    }
}