using ETicaret.DAL.Context;
using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Repository.Service
{
    public class RepositoryService
    {
        private readonly BrandRepository brandRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly ModelRepository modelRepository;
        private readonly OrderDetailRepository orderDetailRepository;
        private readonly OrderRepository orderRepository;
        private readonly ProductCommentRepository productCommentRepository;
        private readonly ProductImageRepository productImageRepository;
        private readonly ProductRepository productRepository;
        private readonly SubCategoryRepository subCategoryRepository;
        private ETicaretContext _context;
        private readonly UserStore<AppUser> userStore;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleStore<AppRole> roleStore;
        private readonly RoleManager<AppRole> roleManager;
        public RepositoryService()
        {
            brandRepository = new BrandRepository();
            categoryRepository = new CategoryRepository();
            modelRepository = new ModelRepository();
            orderRepository = new OrderRepository();
            orderDetailRepository = new OrderDetailRepository();
            productRepository = new ProductRepository();
            productImageRepository = new ProductImageRepository();
            productCommentRepository = new ProductCommentRepository();
            subCategoryRepository = new SubCategoryRepository();
            _context = new ETicaretContext(); ;

            userStore = new UserStore<AppUser>(_context);
            userManager = new UserManager<AppUser>(userStore);
            roleStore = new RoleStore<AppRole>(_context);
            roleManager = new RoleManager<AppRole>(roleStore);
        }
        public BrandRepository Brand => brandRepository;
        public CategoryRepository Category => categoryRepository;
        public ModelRepository Model => modelRepository;
        public OrderRepository Order => orderRepository;
        public OrderDetailRepository OrderDetail => orderDetailRepository;
        public ProductRepository Product => productRepository;
        public ProductImageRepository ProductImage => productImageRepository;
        public ProductCommentRepository ProductComment => productCommentRepository;
        public SubCategoryRepository SubCategory => subCategoryRepository;

        public UserStore<AppUser> UserStore => userStore;
        public RoleStore<AppRole> RoleStore => roleStore;
        public UserManager<AppUser> UserManager => userManager;
        public RoleManager<AppRole> RoleManager => roleManager;
    }
}
