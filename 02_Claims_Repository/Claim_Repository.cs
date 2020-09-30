using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    class Claim_Repository
    {
        private List<Claim> _listOfClaims = new List<Claim>();

        //Create
        public void AddClaimToList(Claim claim)
        {
            _listOfClaims.Add(claim);
        }


        //Read
        public List<Claim> GetClaimList()
        {
            return _listOfClaims;
        }

        //Update
        

        //Delete
        public bool RemoveClaimFromList(int claimID)
        {
            Claim oldClaim = GetClaimByID(claimID);
            int initialClaimCount = _listOfClaims.Count;
            if(oldClaim != null)
            {
                _listOfClaims.Remove(oldClaim);
                if (initialClaimCount > _listOfClaims.Count)
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

        //Get Claim by claimID
        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim claim in _listOfClaims)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }// end of GetClaimByID




    }//end of Claim_Repository
}//end of namespace
