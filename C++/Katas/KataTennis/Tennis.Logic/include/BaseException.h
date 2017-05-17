#pragma once

namespace Tennis
{
    namespace Logic
    {
        class BaseException
        {
        private:
            std::string m_error;

        public:
            explicit BaseException (
                const std::string error )
                : m_error ( error )
            {
            }

            std::string get_error () const
            {
                return m_error;
            }
        };
    };
};
