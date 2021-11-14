using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFilePollService
    {

        /// <summary>
        /// WebHostEnvironment knows where the  data file is stored at
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }


        /// <summary>
        /// Constructor for JsonFilePollService
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFilePollService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// specify file path to retrieve from
        /// </summary>
        private string JsonFileName
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath,
              "data", "polls.json");
            }
        }

        /// <summary>
        /// Deserialize a Json of Polls to List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PollModel> GetPolls()
        {
            //create file reader for Json file 
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                // Deserialize Json to List
                return JsonSerializer.Deserialize<PollModel[]>
                      (jsonFileReader.ReadToEnd(),
                      new JsonSerializerOptions
                      {
                          //make case insensitive
                          PropertyNameCaseInsensitive = true
                      }).OrderBy(x => x.PollID);
            }
        }

        /// <summary>
        /// Save All poll data to storage
        /// </summary>
        /// <param name="polls"></param>
        private void SavePollData(IEnumerable<PollModel> polls)
        {
            using (var outputStream = File.Create(JsonFileName))
            {
                // Serialize Collection to Json
                JsonSerializer.Serialize<IEnumerable<PollModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        //skip validation 
                        SkipValidation = true,

                        //make indented 
                        Indented = true
                    }),
                    polls
                );
            }
        }

        /// <summary>
        /// Return a PollModel based on ID
        /// </summary>
        /// <param name="pollID"></param>
        /// <returns></returns>
        public PollModel GetPoll(int pollID)
        {
            // Get list of Polls
            List<PollModel> polls = GetPolls().ToList();

            // Return Poll found by Poll ID, returns null if ID not found
            return polls.Find(x => x.PollID == pollID);
        }

        /// <summary>
        /// Return a PollModel based on Title
        /// </summary>
        /// <param name="inputTitle"></param>
        /// <returns></returns>
        public PollModel GetPoll(string inputTitle)
        {
            // Get list of Polls
            List<PollModel> polls = GetPolls().ToList();

            // Return Poll found by Poll Title
            return polls.Find(x => x.Title == inputTitle);
        }

        /// <summary>
        /// Checks And Return True if Poll Exist by Title, False Otherwise 
        /// </summary>
        /// <param name="inputTitle"></param>
        /// <returns></returns>
        public bool PollExist(string inputTitle)
        {
            // Fetch A Given Poll
            if (GetPoll(inputTitle) == null)
            {
                // return false for Poll Don't Exists
                return false;
            }

            // return True , for Poll Exists
            return true;
        }

        /// <summary>
        /// Checks And Return True if Poll Exist by ID, False Otherwise 
        /// </summary>
        /// <param name="inputID"></param>
        /// <returns></returns>
        public bool PollExist(int inputID)
        {
            // Fetch A Given Poll
            if (GetPoll(inputID) == null)
            {
                // return false for Poll Don't Exists
                return false;
            }

            // return True , for Poll Exists
            return true;
        }

        /// <summary>
        /// Get OpinionItem from a Poll Model based on Name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pollModel"></param>
        /// <returns></returns>
        public OpinionItem GetOpinion(string name, PollModel pollModel)
        {
            // Check if Poll Model is Null 
            if(pollModel == null)
            {
                return null;
            }

            // Check if Name of Opinion was provided
            if (name == null)
            {
                // No Name was provided
                return null;
            }

            // List of Opinions currently in Poll Model 
            List<OpinionItem> getOpinions = pollModel.OpinionItems.ToList();

            // Check if List is Empty
            if (getOpinions == null)
            {
                // List is empty, no opinion to return
                return null;
            }

            // Fetch Opinion that matches a specific name
            OpinionItem opinion = getOpinions.Find(x => x.OpinionName.Equals(name));

            // return the opinion
            return opinion;
        }

        /// <summary>
        /// Update Vote Of Opinion 
        /// </summary>
        /// <param name="pollID"></param>
        /// <param name="opinionTitle"></param>
        /// <returns></returns>
        public bool UpdatePollModelOpinion(int pollID, string opinionTitle)
        {
            // Poll ID must be greater than -1 
            if(pollID < 0)
            {
                return false;
            }

            // Title cannot be null
            if(opinionTitle == "")
            {
                return false;
            }
            
            // Get List of Polls from Data-Set
            List<PollModel> getPolls = GetPolls().ToList();

            // Get Poll Model based on Poll ID
            PollModel pollModel = GetPoll(pollID);

            // Get Opinion Item based on Title and Poll Model
            OpinionItem opinion = GetOpinion(opinionTitle, pollModel);

            // Remove PollModel from Dataset
            getPolls.RemoveAll(x => x.PollID.Equals(pollID));

            // Remove Opinion Item from Poll Model
            pollModel.OpinionItems.ToList().Remove(opinion);

            // Update Opinion Counter
            opinion.NumCounts += 1;

            // Add Updated Opinion to PollModel
            pollModel.OpinionItems.ToList().Add(opinion);

            // Add PollModel to Dataset
            getPolls.Add(pollModel);

            // Save DataSet
            SavePollData(getPolls);

            return true;
        }


        /// <summary>
        /// Creates and Add New Poll Model to Polls Json Dataset/Database.
        /// </summary>
        /// <param name="newPoll"></param>
        /// <param name="userID"></param>
        /// <returns>PollModel</returns>
        public PollModel CreatePoll(CreatePollModel newPoll, int userID)
        {
            // Boolean for Duplicate Poll Existance 
            bool pollExists = PollExist(newPoll.CreateTitle);

            // True for Duplicate
            if (pollExists)
            {
                // Return Null
                return null;
            }

            // Instantiate a new Poll Model, with attributes
            var poll = new PollModel()
            {
                UserID = userID,
                PollID = GetPolls().Count(),
                Title = newPoll.CreateTitle,
                Description = newPoll.CreateDescription,
                OpinionItems = new List<OpinionItem>() {
                    new OpinionItem(newPoll.CreateOpinionOne, 0), new OpinionItem(newPoll.CreateOpinionTwo, 0)
                }
            };

            // Get Poll Data Set
            var dataSet = GetPolls();

            // Add New Poll to Data Set
            dataSet = dataSet.Append(poll);

            // Convert List into Json DataSet
            SavePollData(dataSet);

            // Return the Instantiated Poll Model 
            return poll;
        }
    }
}