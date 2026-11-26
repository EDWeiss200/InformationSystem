using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class OptFuelPrice: OilCost
    {
        public int MinBatchTons { get; set; }
        public int DeliveryDays { get; set; }

        public OptFuelPrice(string oilType, DateTime date, double cost, int minBatchTons, int deliveryDays)
            : base(oilType, date, cost)
        {
            MinBatchTons = minBatchTons;
            DeliveryDays = deliveryDays;
        }

        public override string ToString()
        {
            return $"OPTOIL Кол-во тонн: {MinBatchTons} Вид топлива: {OilType} Дата: {Date:yyyy.MM.dd} Цена: {Cost}  ДНЕЙ ДОСТАВКИ: {DeliveryDays}";
        }
    }
       


}
