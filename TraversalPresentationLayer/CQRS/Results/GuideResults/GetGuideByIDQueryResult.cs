﻿namespace TraversalPresentationLayer.CQRS.Results.GuideResults
{
    public class GetGuideByIDQueryResult
    {
        public int GuideID { get; set; }
        public string GuideName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
