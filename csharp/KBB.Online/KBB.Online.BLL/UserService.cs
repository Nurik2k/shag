using LiteDB;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KBB.Online.BLL
{
    public class UserService
    {
        private Repository<personal_data> repo = null;
        public UserService(string Path)
        {
            this.Path = Path;
        }

        private string Path { get; set; }
        public List<personal_data> Users { get; set; }

        /// <summary>
        /// Метод для создания пользователя в Базе данных
        /// </summary>
        /// <param name="user">Данные по пользователю</param>
        /// <param name="message">Сообщение об ошибке</param>
        /// <returns></returns>
        /// 

        
        public bool CreateUser(personal_data user, out string message)
        {
            try
            {
                if (GetUser(user.Iin) != null)
                {
                    message = "Пользователь с ИИН: " + user.Iin + " уже зарегистрирован!";
                    return false;
                }
                else
                {
                    repo.Create(user);
                    message = "Successfully";
                    return true;
                    //using (var db = new LiteDatabase(Path))
                    //{
                    //    var users = db.GetCollection<personal_data>("Users");

                    //    users.Insert(user);

                    //    message = "Successfully";
                    //   return true;
                    //}
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public personal_data GetUser(string iin, string psw = null)
        {
            personal_data user = null;
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var users = repo.GetAll().Where(w => w.Iin == iin);
                  
                    if (!string.IsNullOrWhiteSpace(psw))
                    {
                        user = users.FirstOrDefault(f => f.Iin == iin 
                                                            && f.Password == psw);
                    }
                }
            }
            catch
            {
                user = null;
            }

            return user;
        }

        public bool GetUserData(string iin, out string message)
        {
            try
            {
                var restClient = new RestSharp.RestClient("https://meteor.almaty.e-orda.kz");

                var request = new RestRequest("/ru/api-form/load-info-by-iin/?iin=" + iin + "&params[city_check]=true");

                RestResponse response = restClient.Execute(request);

                if (response.ErrorException != null)
                {
                    throw new Exception(
                        "При запросе данных возникла ошибка: " +
                        response.ErrorMessage,
                        response.ErrorException);
                }
                else if (response.Content == "[]")//[]
                {
                    throw new Exception("По введенному ИИН данных нет");
                }
                else
                {
                    User user = JsonConvert
                        .DeserializeObject<User>(response.Content);

                    return CreateUser(user.personal_data, out message);

                    //if (CreateUser(user.personal_data, out message))
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }



    }
}
