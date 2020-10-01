using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class Claim_Repository
    {
        private Queue<Claim> _queueOfClaims = new Queue<Claim>();

        //Create
        public void AddClaimToList(Claim claim)
        {
            _queueOfClaims.Enqueue(claim);
        }


        //Read
        public Queue<Claim> GetClaimList()
        {
            return _queueOfClaims;
        }

        //Update Claim unused at this time Add on Date unknown
        public bool UpdateClaim(Claim updatedClaim)
        {
            int numOfClaims = _queueOfClaims.Count();
            
            //find claim
            Claim claimToUpdate = _queueOfClaims.Dequeue();

            if (numOfClaims < _queueOfClaims.Count())
            {
                //Update Claim content
                if (claimToUpdate != null)
                {
                    claimToUpdate.ClaimID = updatedClaim.ClaimID;
                    claimToUpdate.TypeOfClaim = updatedClaim.TypeOfClaim;
                    claimToUpdate.Description = updatedClaim.Description;
                    claimToUpdate.ClaimAmount = updatedClaim.ClaimAmount;
                    claimToUpdate.DateOfIncident = updatedClaim.DateOfIncident;
                    claimToUpdate.DateOfClaim = updatedClaim.DateOfClaim;
                    claimToUpdate.IsValid = claimToUpdate.IsValid;

                    //add claim back to queue
                    _queueOfClaims.Enqueue(claimToUpdate);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        //Delete
        public bool RemoveClaimFromQueue(int claimID)
        {
            int initialClaimCount = _queueOfClaims.Count;

            Claim oldClaim = _queueOfClaims.Dequeue();
            
            if(oldClaim != null)
            {
               
                if (initialClaimCount > _queueOfClaims.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }//end RemoveClaimFromList

    }//end of Claim_Repository
}//end of namespace
