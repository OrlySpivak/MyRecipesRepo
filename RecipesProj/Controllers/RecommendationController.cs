using System;
using System.Web.Mvc;
using System.IO;
using System.Linq;
using SharpLearning.Containers.Matrices;
using SharpLearning.InputOutput.Csv;
using SharpLearning.Metrics.Classification;
using SharpLearning.Neural;
using SharpLearning.Neural.Activations;
using SharpLearning.Neural.Layers;
using SharpLearning.Neural.Learners;
using SharpLearning.Neural.Loss;
using System.Collections.Generic;

namespace RecipesProj.Models
{
    public class RecommendationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public RecommendationController()
        {
        }

        // GET: RecommendationController
        public ActionResult Index()
        {
            return View();
        }

        // POST:
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Classify([Bind(Include = "Ingrediants")] IList<Ingredient> ingrediants)
        {
            return View(ClassifyWithMl(ingrediants));
        }

        public FoodType ClassifyWithMl(IList<Ingredient> ingrediants)
        {
            #region Read Data

            // Use StreamReader(filepath) when running from filesystem
            var trainingParser = new CsvParser(() => new StringReader(System.IO.File.ReadAllText(@"D:\Programming\VisualStudio\clean\MyRecipesRepo\RecipesProj\Content\ML\training.csv")));
            var testParser = new CsvParser(() => new StringReader(System.IO.File.ReadAllText(@"D:\Programming\VisualStudio\clean\MyRecipesRepo\RecipesProj\Content\ML\training.csv")));

            var targetName = "Class";

            var featureNames = trainingParser.EnumerateRows(c => c != targetName).First().ColumnNameToIndex.Keys.ToArray();

            // read feature matrix (training)
            var matrix = trainingParser.EnumerateRows(featureNames).ToStringMatrix();
            matrix.Map(cellValue => (cellValue.GetHashCode() / 1.0).ToString());

            var trainingObservations = matrix.ToF64Matrix();
            // read classification targets (training)
            var trainingTargets = trainingParser.EnumerateRows(targetName)
                .ToF64Vector();

            // read feature matrix (test) 

            var matrix2 = testParser.EnumerateRows(featureNames).ToStringMatrix();
            matrix2.Map(cellValue => (cellValue.GetHashCode() / 1.0).ToString());

            var testObservations = matrix2.ToF64Matrix();
            // read classification targets (test)
            //var targetMatrix2 = testParser.EnumerateRows(targetName).ToStringMatrix();
            //targetMatrix2.Map(cellValue => (cellValue.GetHashCode() / 1.0).ToString());
            //targetMatrix2 = targetMatrix2.ToF64Matrix()

            //var testTargets = targetMatrix2.ToF64Vector();
            #endregion

            // transform pixel values to be between 0 and 1.
            trainingObservations.Map(p => Math.Abs(Math.Cos(p)));
            testObservations.Map(p => Math.Abs(Math.Cos(p)));

            // the output layer must know the number of classes.
            var numberOfClasses = trainingTargets.Distinct().Count();

            var net = new NeuralNet();
            net.Add(new InputLayer(width: 2, height: 1, depth: 1)); // MNIST data is 28x28x1.
            net.Add(new DropoutLayer(0.2));
            net.Add(new DenseLayer(800, Activation.Relu));
            net.Add(new DropoutLayer(0.5));
            net.Add(new DenseLayer(800, Activation.Relu));
            net.Add(new DropoutLayer(0.5));
            net.Add(new SoftMaxLayer(numberOfClasses));

            // using only 10 iteration to make the example run faster.
            // using classification accuracy as error metric. This is only used for reporting progress.
            var learner = new ClassificationNeuralNetLearner(net, iterations: 10, loss: new AccuracyLoss());
            var model = learner.Learn(trainingObservations, trainingTargets);

            var metric = new TotalErrorClassificationMetric<double>();
            var predictions = model.Predict(testObservations);

            //Trace.WriteLine("Test Error: " + metric.Error(testTargets, predictions));

            var retVal = new FoodType();
            retVal.ID = 1;
            retVal.Type = "type";
            return retVal;
        }

    }
}