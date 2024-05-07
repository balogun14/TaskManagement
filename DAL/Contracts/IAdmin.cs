using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.ViewModels.BlogViewModel;
using TaskManagement.DAL.Contracts;

namespace BlogApplication.DAL.Contracts
{
    public interface IAdmin :IBase<BlogViewModel,CreateBlogViewModel,EditBlogViewModel>
    {
        
    }
}