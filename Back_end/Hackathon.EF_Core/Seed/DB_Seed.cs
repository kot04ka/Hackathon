using Hackathon.EF_Core.Context;
using Hackathon.EF_Core.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.EF_Core.Seed
{
    public static class DB_Seed
    {
        public static async Task SeedDB(this ApplicationContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Users.Any(x => x.UserName == "admin" && x.Password == "admin"))
            {
                await context.Users.AddAsync(new UserDbo() { UserName = "admin", Password = "admin" });
                await context.SaveChangesAsync();
            }

            if (!context.PointAttributes.Any())
            {
                await context.PointAttributes.AddRangeAsync(PointAttributesSeed);
                await context.SaveChangesAsync();
            }

            if (!context.Points.Any())
            {
                await context.Points.AddRangeAsync(PointsSeed(context.PointAttributes));
                await context.SaveChangesAsync();
            }
        }

        private static List<PointAttributeDbo> PointAttributesSeed => new List<PointAttributeDbo>
        {
            new PointAttributeDbo() { Id = 1, Name = "Паркування", Description = "наявність місця для безоплатного паркування транспортних засобів, якими керують особи з інвалідністю."},
            new PointAttributeDbo() { Id = 2, Name = "Пандус", Description = "наявність доступної вхідної групи до установи: пандус"},
            new PointAttributeDbo() { Id = 3, Name = "Понижений вхід", Description = "наявність доступної вхідної групи до установи: понижений вхід (врівень із землею без влаштування ганку)."},
            new PointAttributeDbo() { Id = 4, Name = "Підйомні засоби", Description = "наявність доступної вхідної групи до установи: засоби для підйому (піднімальні платформи, вертикальні підйомники)"},
            new PointAttributeDbo() { Id = 5, Name = "Засоби орієнтації", Description = "наявність системи засобів орієнтації, інформаційної підтримки та безпеки, а саме: тактильні та візуальні елементи доступності, передбачені в будівлях і спорудах (включаючи контрастне маркування кольором першої/останньої сходинки, порогів, інших об’єктів та перешкод)."},
            new PointAttributeDbo() { Id = 6, Name = "Візуальний маршрут", Description = "наявність на шляхах руху засобів візуального орієнтування та інформування: інформаційні термінали, екрани, табло з написами у вигляді рухомого рядка; пристрої для забезпечення текстового або відеозв’язку, перекладу на жестову мову; оснащення спеціальними персональними приладами підсилення звуку; вказівники з інформацією (назва вулиці, номер будинку, назва установи)"},
            new PointAttributeDbo() { Id = 7, Name = "Ліфт", Description = "наявність в установі ліфтів (ширина не менше 1,1 м, глибина не менше - 1,4 м), ескалаторів, підйомників тощо, що є доступними для користування осіб з інвалідністю (крім випадку розміщення приміщень на поверхах вище або нижче поверху основного входу до будівлі (першого поверху))."},
            new PointAttributeDbo() { Id = 8, Name = "Санітарно-гігієнічні приміщення", Description = "наявність в установі санітарно-гігієнічних та інших допоміжних приміщень, розрахованих на осіб з інвалідністю."},
            new PointAttributeDbo() { Id = 9, Name = "Адаптовані системи оповіщення", Description = "наявність в установі пристроїв сповіщення про надзвичайну ситуацію, що адаптовані для сприйняття усіма особами з інвалідністю, насамперед особами, які пересуваються на кріслах колісних, мають порушення зору та слуху"},
            new PointAttributeDbo() { Id = 10, Name = "Перекладач жестової мови", Description = "наявність у штаті установи перекладача української жестової мови або укладено угоду про надання послуг з перекладу українською жестовою мовою з юридичними (фізичними) особами чи передплачено надання відповідного перекладу через мобільні додатки."},
            new PointAttributeDbo() { Id = 11, Name = "Укриття", Description = "наявність в установі укриття або бомбосховища."},
            new PointAttributeDbo() { Id = 12, Name = "Wi-Fi", Description = "наявність в установі вільного доступу до Wi-Fi."},
            new PointAttributeDbo() { Id = 13, Name = "Кімната для догляду", Description = "наявність в установі кімнати для догляду батьків за дітьми до 3х років (місця для перевдягання, пеленання)"},
            new PointAttributeDbo() { Id = 14, Name = "Дитяча кімната", Description = "наявність дитячої кімнати в установі"},
            new PointAttributeDbo() { Id = 15, Name = "Супроводжуючий", Description = "наявність супроводу по установі, відповідальна особа"},
            new PointAttributeDbo() { Id = 16, Name = "Тактильний маршрут", Description = "наявність тактильної навігації до установи від найближчої зупинки громадської транспорту"},
        };

        private static List<PointDbo> PointsSeed(DbSet<PointAttributeDbo> pointAttributes)
        {
            var list = new List<PointDbo>()
            {
                 new PointDbo()
            {
                Name = "ТЦ РайON",
                Latitude = 50.51658449947278m,
                Longitude = 30.602026160513276m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,2,7}).Any(y => y == x.Id)).ToList()
                
            },
            //new PointDbo()
            //{
            //    Name = "ТЦ Festivalnyy",
            //    Latitude = 50.508698559953274m,
            //    Longitude = 30.607253485200992m,
            //    Attributes = pointAttributes.Where(x => (new List<int>(){}).Any(y => y == x.Id)).ToList()
            //},
            new PointDbo()
            {
                Name = "Ощадбанк",
                Latitude = 50.5091591184396m,
                Longitude = 30.607178383350504m,
                Attributes = pointAttributes.Where(x => (new List<int>(){2,16}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "Ощадбанк",
                Latitude = 50.51689336077509m,
                Longitude = 30.616546801298004m,
                Attributes = pointAttributes.Where(x => (new List<int>(){4}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "ТЦ Квадрат",
                Latitude = 50.532505264815796m,
                Longitude = 30.60827230263946m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,4,7}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "ЕКО Маркет",
                Latitude = 50.52956512434788m,
                Longitude = 30.60125673527448m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,2}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "NOVUS",
                Latitude = 50.51393453293557m,
                Longitude = 30.609500788766116m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,2}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "Парк імені Анкари",
                Latitude = 50.512638265723474m,
                Longitude = 30.615208529519485m,
                Attributes = pointAttributes.Where(x => (new List<int>(){3}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "АТБ-Маркет",
                Latitude = 50.51085762409171m,
                Longitude = 30.61715486580857m,
                Attributes = pointAttributes.Where(x => (new List<int>(){4}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "METRO Київ",
                Latitude = 50.511376154768215m,
                Longitude = 30.6239354900787m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,4}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "АТБ-Маркет",
                Latitude = 50.50096176167906m,
                Longitude = 30.585708418257468m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,3}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "Аврора",
                Latitude = 50.501084420126745m,
                Longitude = 30.609741877856404m,
                Attributes = pointAttributes.Where(x => (new List<int>(){0}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "Сінево",
                Latitude = 50.510581208960474m,
                Longitude = 30.62044166106967m,
                Attributes = pointAttributes.Where(x => (new List<int>(){3}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "Sport Life Троєщина",
                Latitude = 50.516629898935435m,
                Longitude = 30.619026540100663m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,4}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "ТЦ \"Милославський\"",
                Latitude = 50.53370975313456m,
                Longitude = 30.60067224765148m,
                Attributes = pointAttributes.Where(x => (new List<int>(){4}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "ТЦ «Корал»",
                Latitude = 50.53384903456147m,
                Longitude = 30.603314729447767m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,2,4}).Any(y => y == x.Id)).ToList()
            },
            new PointDbo()
            {
                Name = "ОККО",
                Latitude = 50.53365126899974m,
                Longitude = 30.60688743180952m,
                Attributes = pointAttributes.Where(x => (new List<int>(){1,3,8}).Any(y => y == x.Id)).ToList()
            }
            };

            return list;
        }

        
}
}
