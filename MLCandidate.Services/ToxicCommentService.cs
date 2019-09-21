using Microsoft.ML;
using MLCandidateML.Model.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MLCandidate.Services
{
    public class ToxicCommentService : IToxicCommentService
    {
        private PredictionEngine<ModelInput, ModelOutput> predEngine;

        public ToxicCommentService()
        {
            var outputDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var modelPath = Path.Combine(outputDir, "MLModel.zip");

            // Load the model
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        public bool IsToxicComment(string comment)
        {
            // Use the code below to add input data
            var input = new ModelInput();
            input.Clean_comment = comment;

            // Try model on sample data
            // True is toxic, false is non-toxic
            var result = predEngine.Predict(input);
            return result.Prediction;
        }
    }
}
