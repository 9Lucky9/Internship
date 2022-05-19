АРI для добавления и чтения рецензий на игры.
Используемые технологии: REST, .Net 6, EF core, MS SQL, SQL server express

Возможности приложения:

1) Добавить и удалить игру:
2) Добавить рецензию и оценку на игру:
3) Получить все игры в сортировке по оценке по убыванию;
4) Получить игру и список всех её рецензий и оценок.

В базе данных хранятся игры и рецензии.

Игра хранится в виде:
1. Идентификатор;
2. Наименование;
3. Жанр.

Рецензии хранятся в виде:
1. Идентификатор;
2. Игра;
3. Рецензия;
4. Оценка.

Дополнительные фичи:
Добавление приписки "Рекомендовано" к жанру игры с помощью миграции базы данных с использованием EF core без прямого доступа к базе данных, 

Добавление Middleware для расшифровки токена.

Добавление OpenAPI (Swagger).
