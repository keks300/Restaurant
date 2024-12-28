## Предметная область проекта “Ресторан”
### Данный проект представляет собой проект написанный ASP NET CORE API для управления рестораном, позволяющий взаимодействовать с клиентами, заказывать и отслеживать доставку блюд.

```mermaid
erDiagram
    Customer {
        Guid Id
        string FullName
        string Email
        string Phone
        DateTimeOffset CreatedAt
        DateTimeOffset UpdatedAt
        DateTimeOffset Deleted
    }
    Order {
        Guid Id
        Guid CustomerId
        decimal TotalAmount
        DateTimeOffset CreatedAt
        DateTimeOffset UpdatedAt
        DateTimeOffset Deleted
    }
    Delivery {
        Guid Id
        Guid OrderId
        string DeliveryAddress
        datetime DeliveryDate
        Status Status
        DateTimeOffset CreatedAt
        DateTimeOffset UpdatedAt
        DateTimeOffset Deleted
    }
    OrderDish {
        Guid Id
        Guid OrderId
        Guid DishId
        int Quantity
        DateTimeOffset CreatedAt
        DateTimeOffset UpdatedAt
        DateTimeOffset Deleted
    }
    Dish {
        Guid Id
        string Name
        decimal Price
        string Description
        DateTimeOffset CreatedAt
        DateTimeOffset UpdatedAt
        DateTimeOffset Deleted
    }

    Customer ||--o| Order : ""
    Order ||--o| OrderDish : ""
    Order ||--|| Delivery : ""
    OrderDish }|--|| Dish : ""
