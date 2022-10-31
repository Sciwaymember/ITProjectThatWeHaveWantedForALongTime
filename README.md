# ITProjectThatWeHaveWantedForALongTime
Проект для ребят из АЙТИ компании от ребят из не АЙТИ компании с возможным потенциалом подзаработать вторым ребятам. Но и просто потому что всегда хотел свой АЙТИ проект. И вообще.

Библиотека книг/ сервис для желающих перевести что нибудь, с конкурсами и тамадой Пользователи находят книги и/или добавляют свои переводы.

## Структура системы MVP
Система **_свой АЙТИ проект. И вообще._** состоит из компонентов:

__*Authorization server*__  
Компонент, в котором осуществляется логин, регистрация и управлением аккаунтов пользователя.  
*Путь к нему далее будет описан как /authpath*

__*Library app*__  
Приложение, в котором осуществляется навигация по страницам сайта, в том числе поиск книг и их редактирование пользователем.  
*Путь к нему далее будет описан как /webpath*

__*Library server*__  
Компонент Модели, в котором осуществляется поиск и сохранение необходимой информации в базах данных, а так же  обмен данными с *Library app*  
*Путь к нему далее будет описан как /apipath*


## Основной флоу системы
Веб страницы, помеченные как ***(Только для зарегистрированных пользователей)*** перенаправляют неавторизированных пользователей на страницу входа/регистрации.

1. Любой пользователь заходящий на сайт попадает на landing page, на которой имеется поле для поиска;![Alt text](https://i.imgur.com/frCfljS.jpg "/webpath")
2. При вводе поискового запроса пользователь получает книги, Название или автор которых соответствуют поисковому запросу. ![Alt text](https://i.imgur.com/yxcfl3e.jpg "/webpath?some-search-query") (request) При этом *Library app* посылает GET запрос к "*/apipath/searchBooks*" с параметрами поиска в *body* и получает массив упрощенных обьектов книг (c ключевой информацией);
3. При выборе книги, пользователь получает интерфейс со всей информацией и доступными версиями на разных языках, в том числе и переводы созданные пользователями **/здесь возможно (если в отдельном окне) необходима картинка дизайна Списка версий книги "/webpath/book/:bookID/:versionID/:chapterNumber"**  (request) Запрос от *Library app*: GET from */apipath/book/:bookID/:versionID*
4. Пользователь может выбрать одну из версий книги чтобы прочитать её прямо на сайте. Тогда Для него открывается интерфейс с информацией о конкретной версии (год выпуска, издатель, язык), а так же списком глав, к которым он может перейти для чтения. (Возможно глава будет открываться под плашкой, в отдельном окне неудобно, но если будет в отдельном окне тогда к каждой главе должна быть припечатана ссылка на прошлую и следующую главу.) ![Alt text](https://i.imgur.com/kawKidh.jpg "/webpath/book/:bookID/:versionId") (request) Запрос от *Library app*: GET from */apipath/book/:bookID/:versionID*, а также GET from */apipath/book/:bookID/:versionID/:chapterNumber*
5. На сайте присутствует возможность регистрации, некоторые функции доступны только зарегистрированным пользователям. _(возможно можно залогиниться через Гугл или Гитхаб, может и нет)_ **/здесь необходима картинка дизайна страницы логина/регистрации по ссылке /webpath/signin**"") (request) Запрос от *Library app*: POST к */authpath/login* или */authpath/signup*, в ответ получает свой токен, который хранит в безопасных cookies браузера. _(тип токена и способы его хранения на сервере нуждаются в дополнительном обсуждении)_
6. (Только для зарегистрированных пользователей) У каждого пользователя есть личный кабинет, в котором единственная функция: он может посмотреть те переводы которые он создал (законченные и в процессе) **/здесь необходима картинка дизайна доступа к личному кабинету по ссылке /webpath/mytranslations** (request) Запрос от *Library app*: GET from */apipath/usersTranslation/personal* (personal используется чтобы достать юзер айди с помощью авторизации, далее логика схожа с */apipath/usersTranslation/:userID*).
7. (Только для зарегистрированных пользователей) Если пользователь желает запросить/создать перевод (запрос это дополнительная функция, низкий приоритет) его перенаправляют на страницу создания пустого проекта перевода где он заполняет необходимые детали  **/здесь необходима картинка (https://i.imgur.com/jwUUajZ.jpg) дизайна создания проекта по ссылке /webpath/book/:bookID/newVersion**. (request) Как только пользователь закончит создание проекта *Library app* отправляет POST запрос со всей информацией на */apipath/book/:bookID/newVersion* ну да окей блятья понял
8. Если пользователь сам решил создать перевод, то эта версия книги автоматически закреплена за ним (свойство автора перевода в обьекте версии книги). Если же это был запрос на перевод, то свойство автора перевода остается пустым. *Остальная обработка запроса на перевод будет описана в дополнительных функциях приложения.*
9. Как только пустой проект создан и закреплен за пользователем автор может получить к нему доступ из личного кабинета а так же по ссылке "*/webpath/book/:bookID/:versionID*" для чтения или "*/webpath/book/:bookID/:versionID/edit*" для редактирования. В режиме редактирования пользователь попадает на страницу, в которой он может выбрать главу/часть над которой он хочет работать  а так же на этой странице имеет всю информацию о книге (референсы в п.3, п.4). В режиме редактирования главы пользователь имеет зеркальные поля, одно из которых для ввода текста, а другое (эталонное поле) содержит оригинал переводимой книги (либо ту версию, которую выберет пользователь) ![Alt text](https://i.imgur.com/EX4Gf0U.jpg "/webpath/book/:bookID/:versionID/edit") (request) После окончания работы над главой пользователь сохраняет её с помощью Запроса от *Library app*: POST  to "*/webpath/book/:bookID/:versionID/:chapterID*"
10. Когда перевод закончен (либо заморожен, обработка заморозки проекта будет описана в дополнительных функциях приложения), пользователь может выложить его на сайт с помощью предназначенной для этого кнопки, тогда перевод будет отображаться в списке версий книги. (request) В таком случае запрос от *Library app*: POST  to "*/webpath/book/:bookID/:versionID/finish*"  
11. (Только для зарегистрированных пользователей) Пользователь может добавить новую книгу, если он не нашел её на сайте. Для этого ему необходимо нажать на предназначенную для этого кнопку на сайте (предлагаю переместить её из контекстного меню сверху на куда нибудь вроде "я не нашел нужной мне книги" после поиска"). После этого он попадает в меню, где указывает все необходимые данные, а так же добавляет файл книги (возможны разные форматы, необходимо определить и обработать каждый из них) **/здесь необходима картинка дизайна создания новой книги по ссылке /webpath/book/new**.  (request) После окончания работы над информацией о книге пользователь сохраняет её с помощью Запроса от *Library app*: POST  to "*/webpath/book/new*"
12. (Только для зарегистрированных пользователей) Пользователь может добавить существующий перевод для книги, если он не нашел его среди вариантов книги. Для этого ему необходимо нажать на предназначенную для этого кнопку на сайте (предлагаю поместить её в меню книги  из п.3). После этого он попадает в меню, где указывает все необходимые данные, а так же добавляет файл книги (возможны разные форматы, необходимо определить и обработать каждый из них).(Скорее всего это будет то же самое меню из п.7, с дополнительными полями издателя и вставки книги) **/здесь необходима картинка дизайна создания новой существующей версии по ссылке /webpath/book/:bookID/existingVersion**. (request) После того как пользователь закончил, он сохраняет с помощью Запроса от *Library app*: POST  to "*/webpath/book/:bookID/existingVersion*"
13. Каждая добавленная пользователем книга, законченный перевод или существующая версия должна проходить модерацию, способ модерации будет обсужден и добавлен в тех.задание позже, на начальных этапах модерация отсутствует.

###### Readme end