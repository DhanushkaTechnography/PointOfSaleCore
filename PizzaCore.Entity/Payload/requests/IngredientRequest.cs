namespace PizzaCore.Entity.Payload.requests
{
    public class IngredientRequest
    {
        public int IngredientsId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public int Status { get; set; }

        public IngredientRequest()
        {
        }

        public IngredientRequest(int ingredientsId, int pizzaId, int toppingId, int status)
        {
            IngredientsId = ingredientsId;
            PizzaId = pizzaId;
            ToppingId = toppingId;
            Status = status;
        }
    }
}