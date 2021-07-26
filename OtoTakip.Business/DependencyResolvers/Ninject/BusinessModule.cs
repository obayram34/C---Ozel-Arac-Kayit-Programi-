using Ninject.Modules;
using OtoTakip.Business.Abstract;
using OtoTakip.Business.Concrete;
using OtoTakip.Business.Concrete.EntityFramework;
using OtoTakip.DataAccess.Abstract;
using OtoTakip.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.DependencyResolvers.Ninject
{
  public  class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAracListesiService>().To<AracListesiManager>().InSingletonScope();
            Bind<IAraclistesiDAL>().To<EfAracListesiDAL>().InSingletonScope();

            Bind<IMusterilerService>().To<MusterilerManager>().InSingletonScope();
            Bind<IMusterilerDAL>().To<EfMusterilerDAL>().InSingletonScope();

            Bind<IKategorilerService>().To<KategorilerManager>().InSingletonScope();
            Bind<IKategorilerDAL>().To<EfKategorilerDAL>().InSingletonScope();

            Bind<IKasaService>().To<KasaManager>().InSingletonScope();
            Bind<IKasaDAL>().To<EfKasaDAL>().InSingletonScope();

            Bind<IKiraTipService>().To<KiraTipsManager>().InSingletonScope();
            Bind<IKiraTipDAL>().To<EfKiraTipDAL>().InSingletonScope();

            Bind<IAracDetaylarService>().To<AracDetaylarManager>().InSingletonScope();
            Bind<IAracDetaylarDAL>().To<EfAracDetaylarDAL>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDAL>().To<EfUserDAL>().InSingletonScope();
        }
    }
}
