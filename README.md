# TechGround Hackathon #2 | Luxoft / Hackathon Task

1. Вступ. Ознайомлення з проєктом.

Команда Благодійного Фонду «Солом'янських котиків» рада познайомити із ініціативою – Безбар'єрної мапи Києва.

Проєкт рішення передбачає позначення безбар'єрних маршрутів та доступних для людей на колісних візках місць на мапі, а також подальше включення відповідного сервісу до додатка «Київ Цифровий».

«Концепція проєкту повністю відповідає національній стратегії безбар'єрності. Така мапа дозволить нам не тільки зробити навігацію у Києві зручнішою, але і зрозуміти, як нам рухатися до повністю безбар'єрного і зручного міста»

Ксенія Семенова, Співзасновниця благодійного фонду «Солом'янські котики»



2. Технічне завдання на реалізацію безбар'єрної мапи Києва

Мета цього проєкту – розробити маршрутний сервіс для онлайн/офлайн мап, що дозволить будувати маршрути доступності для людей на колісних візках, враховуючи параметри доступності. Важливо: для побудови маршрутів, необхідно спочатку оцифрувати дороги, які облаштовані для людей на колісних візках.

1. Формування класифікації типів об'єктів мапи
   Потрібно виокремити типізаційні ознаки, які будуть покладені в основу розроблення графічних стилів.
   Формування класифікаційного опису об’єктів передбачає створення системи класифікації та опису ознак, що використовуються для визначення типу геопросторового об’єкта та його характеристик на мапі або в базі геоданих.
   Цей опис має містити інформацію про назву ознаки, її опис, тип даних, які вона містить та можливі значення. Наприклад, для класифікації типів закладів можуть бути використані такі ознаки: «Школа», «Комунальна установа» та інші.

2. Основні вимоги до оформлення
   Шрифти та елементи оформлення повинні базуватися на принципах картографічного дизайну та естетичності. До основних принципів слід віднести:
   інформативність підписів на базовій мапі в заданому масштабі;
   насиченість підписів на базовій мапі в заданому масштабі;
   формування складних підписів за необхідності;
   формування масштабної та інформаційної ієрархії відображення підписів;
   можливість забезпечення додаткових підписів.
   Розроблений сервіс має відповідати рекомендаціям інклюзивного UX дизайну, більше про це за посиланням.

3. Основні вимоги операції із об'єктами мапи
   Необхідно реалізувати операції з об’єктом, для якого повинні визначатись параметри доступності, а саме:
1) Пошук об’єкта.
2) Перегляд об’єкта.
3) Створення об’єкта.
4) Редагування об’єкта.

Можливий перелік атрибутів об’єкта, для якого визначаються параметри доступності:
Паркування – наявність місця для безоплатного паркування транспортних засобів, якими керують особи з інвалідністю.
Пандус – наявність доступної вхідної групи до установи: пандус
Понижений вхід – наявність доступної вхідної групи до установи: понижений вхід (врівень із землею без влаштування ганку).
Підйомні засоби – наявність доступної вхідної групи до установи: засоби для підйому (піднімальні платформи, вертикальні підйомники)
Засоби орієнтації – наявність системи засобів орієнтації, інформаційної підтримки та безпеки, а саме: тактильні та візуальні елементи доступності, передбачені в будівлях і спорудах (включаючи контрастне маркування кольором першої/останньої сходинки, порогів, інших об’єктів та перешкод).
Візуальний маршрут – наявність на шляхах руху засобів візуального орієнтування та інформування: інформаційні термінали, екрани, табло з написами у вигляді рухомого рядка; пристрої для забезпечення текстового або відеозв’язку, перекладу на жестову мову; оснащення спеціальними персональними приладами підсилення звуку; вказівники з інформацією (назва вулиці, номер будинку, назва установи)
Ліфт – наявність в установі ліфтів (ширина не менше 1,1 м, глибина не менше – 1,4 м), ескалаторів, підйомників тощо, що є доступними для користування осіб з інвалідністю (крім випадку розміщення приміщень на поверхах вище або нижче поверху основного входу до будівлі (першого поверху)).
Санітарно-гігієнічні приміщення – наявність в установі санітарно-гігієнічних та інших допоміжних приміщень, розрахованих на осіб з інвалідністю.
Адаптовані системи оповіщення – наявність в установі пристроїв сповіщення про надзвичайну ситуацію, що адаптовані для сприйняття усіма особами з інвалідністю, насамперед особами, які пересуваються на кріслах колісних, мають порушення зору та слуху
Перекладач жестової мови – наявність у штаті установи перекладача української жестової мови або укладено угоду про надання послуг з перекладу українською жестовою мовою з юридичними (фізичними) особами чи передплачено надання відповідного перекладу через мобільні додатки.
Укриття – наявність в установі укриття або бомбосховища.
Wi-Fi – наявність в установі вільного доступу до Wi-Fi.
Кімната для догляду – наявність в установі кімнати для догляду батьків за дітьми до 3х років (місця для перевдягання, пеленання)
Дитяча кімната – наявність дитячої кімнати в установі
Супроводжуючий – наявність супроводу по установі, відповідальна особа
Тактильний маршрут – наявність тактильної навігації до установи від найближчої зупинки громадської транспорту

4. Побудова маршрутів
   Окрім того, що на мапі будуть позначені об'єкти (кафе, супермаркети, заклади освіти, парки, вулиці, перехрестя, громадський транспорт, житлові будинки) та місця, де вже створена певна інклюзивна інфраструктура (вхід в рівень з тротуаром, пандус, понижений бордюр, вбиральня для людей з інвалідністю, світлофор зі звуковим сигналом тощо), головним функціоналом мапи повинна бути побудова просторового маршруту для людей на колісних візках згідно наявної та доступної на шляху інклюзивної інфраструктури.



3. Опис вхідних даних та обмеженнь

За базу комерційних об'єктів, інклюзивної інфраструктури рекомендуємо взяти існуючий сервіс, що розроблений командою ЛУН – Карта інклюзивності.
Базу державних установ можна знайти за посиланням.
В рамках хакатону команда може взяти на опрацювання один район Києва, та декілька різних типів об'єктів, щоб представити на мапі основний функціонал.
Технічні вимоги (для додаткового ознайомлення та не є обов'язковими) за посиланням.

☝️ Команди можуть запропонувати свої рішення та ідеї реалізації мапи безбар'єрності, та головне побудови оптимального маршруту для людей на колісних візках.
Не обмежуйтесь наданими референсами та вимогами, обмежень по вибору технічного стеку не має.
