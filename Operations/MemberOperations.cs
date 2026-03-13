

using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;

namespace LibraryManagementSystem.Operations
{
     class MemberOperations
    {
        private static AppDbContext context =new AppDbContext();
        public static Member SearchMember(int memberId)
        {
            var existingMember = context.Members.FirstOrDefault(x => x.Id == memberId);
            if (existingMember == null)
            {
                throw new ArgumentException($"Member does not exist.");
            }
            return existingMember;
        }
        public static void AddMember(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
        }

        public static void UpdateMember(Member member,int memberId)
        {
           
            var existingMember = SearchMember(memberId);
            existingMember.Name = member.Name;
            existingMember.Email = member.Email;
            existingMember.Phone = member.Phone;
            existingMember.Address = member.Address;
            existingMember.JoinDate = member.JoinDate;
            existingMember.MembershipStatus = member.MembershipStatus;
            context.SaveChanges();

        }
        public static bool DeleteMember(int memberId)
        {
        
            var existingmember = SearchMember(memberId);
            context.Members.Remove(existingmember);
            context.SaveChanges();
            return true;
        
    }
        public static List<BorrowTransaction> AllBorrowTransactionOfMember(int memberId)
        {
            var existingmember = SearchMember(memberId);
            List<BorrowTransaction> result =context.BorrowTransactions.Where(x=>x.MemberId == memberId).ToList();
            return result;
        }
    }
}
