using dan_storbaek_server.Domains;

namespace dan_storbaek_server.Services
{
    public class BinaryStringService : IBinaryStringService
    {
        public BinaryStringStatus Analyze(string data)
        {
            var equalZeroAndOne = IsEqualZeroAndOne(data);
            var prefixOneGtOrEqual = isEveryPrefixOneGtOrEqualNoOfZero(data);

            return new BinaryStringStatus
            {
                EqualZeroAndOne = equalZeroAndOne,
                PrefixOneGtOrEqualZero = prefixOneGtOrEqual,
            };
        }

        private bool IsEqualZeroAndOne(string str)
        {
            int count0 = 0, count1 = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                {
                    count0++;
                } else
                {
                    count1++;
                }
            }

            if(count0 == count1)
            {
                return true;
            }
            return false;
        }

        private bool isEveryPrefixOneGtOrEqualNoOfZero(string str)
        {
            bool isOneGreater = true;
            for (int i = 0; i < str.Length - 1; i++)
            {
                string prefix = str.Substring(0, i + 1);
                bool isPrefixOneGtEqual = IsNoOfOneGtOrEqualNoOfZero(prefix);
                if(!isPrefixOneGtEqual)
                {
                    isOneGreater = false;
                }
            }
            return isOneGreater;
        }

        private bool IsNoOfOneGtOrEqualNoOfZero(string str)
        {
            int count0 = 0, count1 = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                {
                    count0++;
                }
                else
                {
                    count1++;
                }
            }

            if(count1 >= count0) 
            { 
                return true; 
            }
            return false;
        }
    }
}
