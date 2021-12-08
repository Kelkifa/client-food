# client-food

## API SERVER
- JSON API cho app
https://xamarin-food.herokuapp.com/api/food/json

- Trang web để xem xoá sửa food:
https://xamarin-food.herokuapp.com/food/list

- Trang web để tạo food:
https://xamarin-food.herokuapp.com/food/create

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
