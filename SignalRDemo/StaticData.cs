namespace SignalRDemo
{
    public class StaticData
    {
        public List<ModelDto> Data { get; private set; }

        public StaticData()
        {
            Data = new List<ModelDto>
            {
                new ModelDto
                {
                    Id = 1,
                    Title = "Antique Vase",
                    ImageUrl = "https://example.com/images/vase.jpg",
                    EstimatePrice = "$100 - $200",
                    CurrentBid = "$120",
                    IsSold = "No",
                    Price = "$150"
                },
                new ModelDto
                {
                    Id = 2,
                    Title = "Vintage Watch",
                    ImageUrl = "https://example.com/images/watch.jpg",
                    EstimatePrice = "$200 - $400",
                    CurrentBid = "$250",
                    IsSold = "No",
                    Price = "$300"
                },
                new ModelDto
                {
                    Id = 3,
                    Title = "Painting",
                    ImageUrl = "https://example.com/images/painting.jpg",
                    EstimatePrice = "$500 - $700",
                    CurrentBid = "$600",
                    IsSold = "Yes",
                    Price = "$650"
                }
            };
        }
    }
}
