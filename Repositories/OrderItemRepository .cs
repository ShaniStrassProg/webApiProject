//using Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Text.Json;

//namespace Repositories
   
//{
//    public class UserRepository : IUserRepository
//    {
//        private PhotoGalleryContext _photoGalleryContext;
//        public UserRepository(PhotoGalleryContext photoGalleryContext)
//        {
//            _photoGalleryContext = photoGalleryContext;
//        }
//        public async Task<User> getUserById(int id)
//        {
//            var foundUser = await _photoGalleryContext.Users.FindAsync(id);
//            if (foundUser == null)
//                return null;
//            return foundUser;

//            //using (StreamReader reader = System.IO.File.OpenText("../Users.txt"))
//            //{
//            //    string? currentUserInFile;
//            //    while ((currentUserInFile = reader.ReadLine()) != null)
//            //    {
//            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
//            //        if (user.UserId == id)
//            //            return user;

//            //    }
//            //    return null;
//            //}
//        }
//        public async Task<User> GetUserByEmailAndPassword(UserLogin userLogin)
//        {
//            var s= await _photoGalleryContext.Users.Where(e => e.Email == userLogin.Email && e.Password == userLogin.Password).FirstOrDefaultAsync();
//            return s; 
            
//            //using (StreamReader reader = System.IO.File.OpenText("Users.txt"))
//            //{
//            //    string? currentUserInFile;
//            //    while ((currentUserInFile = reader.ReadLine()) != null)
//            //    {
//            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
//            //        if (user.Email == userLogin.Email && user.Password == userLogin.Password)
//            //            return user;
//            //    }

//            //}
//            //return null;
//        }

//        public async Task<User> addUser(User user)
//        {
//            try { 
//             await _photoGalleryContext.Users.AddAsync(user);
//            await _photoGalleryContext.SaveChangesAsync();
//            return user;
//            }
//            catch(Exception ex)
//            {
//                throw ex;
//            }
//            //Console.WriteLine("register");
//            //string filePath = "Users.txt";
//            //int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
//            //user.UserId = numberOfUsers + 1;
//            //string userJson = JsonSerializer.Serialize(user);
//            //System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
//            //return user;

//        }
//        public async Task<User> updateUser(int id, User userToUpdate)
//        {
//            var foundUser = await _photoGalleryContext.Users.FindAsync(id);
//            if (foundUser == null)
//                return null;
//            _photoGalleryContext.Entry(foundUser).CurrentValues.SetValues(userToUpdate);
//            await _photoGalleryContext.SaveChangesAsync();
//            return userToUpdate;
//        }
//        //    string textToReplace = string.Empty;
//        //    string filePath = " Users.txt";
//        //    using (StreamReader reader = System.IO.File.OpenText("Users.txt"))
//        //    {
//        //        string currentUserInFile;
//        //        while ((currentUserInFile = reader.ReadLine()) != null)
//        //        {

//        //            User user = JsonSerializer.Deserialize<User>(currentUserInFile);
//        //            if (user.UserId == id)
//        //                textToReplace = currentUserInFile;
//        //        }
//        //    }

//        //    if (textToReplace != string.Empty)
//        //    {
//        //        string text = System.IO.File.ReadAllText("Users.txt");
//        //        text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
//        //        System.IO.File.WriteAllText("Users.txt", text);
//        //        return true;
//        //    }
//        //    return false;

//        //}

       
//    }
//}
