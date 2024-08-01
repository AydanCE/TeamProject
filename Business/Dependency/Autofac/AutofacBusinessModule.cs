using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dependency.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<SubCategoryManager>().As<ISubCategoryService>().SingleInstance();
            builder.RegisterType<EFSubCategoryDal>().As<ISubCategoryDal>().SingleInstance();

            builder.RegisterType<ProductToSubCategoryManager>().As<IProductToSubCategoryService>().SingleInstance();
            builder.RegisterType<EFProductToSubCategoryDal>().As<IProductToSubCategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EFUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<RegionManager>().As<IRegionService>().SingleInstance();
            builder.RegisterType<EFRegionDal>().As<IRegionDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EFOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<OrderToProductManager>().As<IOrderToProductService>().SingleInstance();
            builder.RegisterType<EFOrderToProductDal>().As<IOrderToProductDal>().SingleInstance();

            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<EFBlogDal>().As<IBlogDal>().SingleInstance();

            builder.RegisterType<FaqManager>().As<IFaqService>().SingleInstance();
            builder.RegisterType<EFFaqDal>().As<IFaqDal>().SingleInstance();

            builder.RegisterType<PrivacyPolicyManager>().As<IPrivacyPolicyService>().SingleInstance();
            builder.RegisterType<EFPrivacyPolicyDal>().As<IPrivacyPolicyDal>().SingleInstance();

            builder.RegisterType<TermsAndConditionManager>().As<ITermsAndConditionService>().SingleInstance();
            builder.RegisterType<EFTermsAndConditionDal>().As<ITermsAndConditionDal>().SingleInstance();

            builder.RegisterType<AboutUsManager>().As<IAboutUsService>().SingleInstance();
            builder.RegisterType<EFAboutUsDal>().As<IAboutUsDal>().SingleInstance();


        }
    }
}
