using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApplication.DAL.Contracts;
using BlogApplication.Dto.Author;
using BlogApplication.Models;
using BlogApplication.ViewModels.BlogViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;

namespace BlogApplication.DAL.Repository
{
    public class AdminRepo : IAdmin
    {
        private readonly ApplicationDbContext _appDb;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly INotyfService _notyfService;
        private readonly UserManager<User> _userManager;

        private readonly IAuthor _author;
        private readonly IBlogRepo _blogRepo;
        public AdminRepo(ApplicationDbContext _appDb, IHttpContextAccessor httpContextAccessor, INotyfService _notyfService, IAuthor author, UserManager<User> userManager, IBlogRepo _blogRepo)
        {
            this._appDb = _appDb;
            this._httpContextAccessor = httpContextAccessor;
            this._notyfService = _notyfService;
            this._author = author;
            this._userManager = userManager;
            this._blogRepo = _blogRepo;
        }
        public async Task Create(CreateBlogViewModel createEntity)
        {
            var currentUser = await Utility.Helper.GetCurrentUserIdAsync(_httpContextAccessor, _userManager);
            var authorDto = await _author.GetById(Guid.Parse(currentUser.userId));
            if (authorDto != null)
            {
                var author = new Author
                {
                    Id = Guid.Parse(currentUser.userId),
                    Name = authorDto.Name,
                    Bio = authorDto.Bio
                };
                var blog = new Blog()
                {
                    ID = Guid.NewGuid(),
                    Body = createEntity.Body,
                    Name = createEntity.Name,
                    Status = createEntity.Status,
                    DateCreated = DateTime.Now,
                    AuthorId = author.Id
                };
                await _appDb.Blogs.AddAsync(blog);
                await _appDb.SaveChangesAsync();
            }
            else
            {
                var existingAuthor = await _author.GetById((Guid.Parse(currentUser.userId)));
                if (existingAuthor == null)
                {
                    var author = new CreateAuthorDto(
                        Id: Guid.Parse(currentUser.userId),
                        Name: currentUser.userName,
                        Bio: "Hello"
                    );
                    await _author.Create(author);
                    await Create(createEntity);
                }
                else
                {
                    var author = new Author()
                    {
                        Id = Guid.Parse(currentUser.userId),
                        Name = existingAuthor.Name,
                        Bio = existingAuthor.Bio
                    };
                    var blog = new Blog()
                    {
                        ID = Guid.NewGuid(),
                        Body = createEntity.Body,
                        Name = createEntity.Name,
                        Status = createEntity.Status,
                        DateCreated = DateTime.Now,
                        AuthorId = author.Id
                    };
                    await _appDb.Blogs.AddAsync(blog);
                    await _appDb.SaveChangesAsync();
                }
            }
            _notyfService.Success("Blog Created Successfully");
        }

        public async Task<bool> Delete(Guid id)
        {
            var rowAffected = await _appDb.Blogs.Where(e => e.ID == id).ExecuteDeleteAsync();
            return rowAffected != 0;
        
        }

        public async Task<IEnumerable<BlogViewModel>?> GetAll()
        {
            var blogs = await _blogRepo.GetBlog()!;

            return blogs;

        }

        public async Task<BlogViewModel?> GetById(Guid Id)
        {
            var blog = await _blogRepo.GetBlog(Id);
            return blog;
        }

        public async Task<bool> Update(EditBlogViewModel editEntity)
        {
            var rowAffected = await _appDb.Blogs.Where(x => x.ID == editEntity.ID).ExecuteUpdateAsync(s => s.SetProperty(e => e.Name, editEntity.Name).SetProperty(e => e.Body, editEntity.Body).SetProperty(e => e.Status, editEntity.Status));
            return rowAffected != 0;

        }
    }
}