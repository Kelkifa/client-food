# client-food

## API SERVER
Food
- JSON API cho app
https://xamarin-food.herokuapp.com/api/food/json
- JSON API cho app để search
https://xamarin-food.herokuapp.com/api/food/json?s=SEARCH_GI_DO

- Trang web để xem xoá sửa food:
https://xamarin-food.herokuapp.com/food/list

- Trang web để tạo food:
https://xamarin-food.herokuapp.com/food/create

Auth
- Register api [POST] https://xamarin-food.herokuapp.com/api/auth/register
- Login api [POST https://xamarin-food.herokuapp.com/api/auth/login

## Server github link:
https://github.com/Kelkifa/xamarin-server-food

## API Food schema:
```js
const foods = new Schema(
    {
        name: { type: String },
        type: { type: String },
        image: { type: String },
        description: { type: String },
        production: { type: String },
        cost: { type: Number },
        unit: { type: String },
        minMass: { type: String, default: "0kg" },
        maxMass: { type: String, default: "0kg" }
    },
```
