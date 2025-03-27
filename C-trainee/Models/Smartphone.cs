namespace C_trainee.Models
{
    public class Smartphone
    {
        public int Id { get; set; }
        public string Model { get; set; }          // Модель 
        public string Manufacturer { get; set; }   // Производитель 
        public decimal PriceRUB { get; set; }         // Цена
        public int StorageGB { get; set; }         // Память в ГБ
        public bool Has5G { get; set; }            // Поддержка 5G
        public DateTime ReleaseDate { get; set; }  // Дата выхода
    }
}
