# CoreProject

Проект выполнен как первый опыт с ASP .NET 6.0.
Проект не является готовым продуктом, а служит для демонстрации навыков работы с технологией.

# Реализованный функционал:

Наличие локальной базы данных, содержащих связанные таблицы, такие как Car, Category, User и другие
На главной странице перечислен список всех автомобилей, на страницах /Cars/List/fuel и /Cars/List/electro перечислены автомобили с соответствующими категориями. Доступ к этим страницам возможен через ручное добавление адреса, либо через переход по ссылкам с элемента header.

Реализована собственная система регистрации и входа, с наличием пользователей с ролями Standart и Admin. Добавление роли Admin на текущий момент возможен только через ручное редактирование базы данных. При регистрации пользователей происходит проверка на наличие почты и имени пользователя, и при успешной валидации новый пользователь добавляется в БД.
Если зайти под юзером с ролью админ (Login:Admin Password:admin123), то на элементе footer будет доступна ссылка на админ панель. Админ панель недоступна обычным пользователям и незалогиневшимся пользователям, при попытке попасть туда они переадресовываются на главную страницу.
Система авторизации работает на хранении данных, в частности currentLogin и currentPassword внутри сессии.

Есть система добавления автомобилей в корзину и дальнейшая оплата.

# Возможные улучшения

Замена собственно написанной системы регистрации на предназначенную для этого, соблюдающую принципы безопасности передачи данных.

Сейчас оформление заказов возможно в том числе и для незарегистрированных пользователей. При необходимости отключить эту возможность.

Код не претендует на полную чистоту и оптимизированность. Например в /Data/Mocks присутствуют два файла, отвечающие за добавку машин и категорий, когда БД еще не была подключена. 
Эти файлы не участвуют в работе проекта, но оставлены как демонстрация других способов добавления данных.
