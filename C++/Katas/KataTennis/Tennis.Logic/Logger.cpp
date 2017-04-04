#include <string>
#include "include/Logger.h"

namespace Tennis
{
    namespace Logic
    {
        void Logger::log (
            std::string type,
            std::string message ) const
        {
            m_ostream << type << " " << message << '\n';
        }

        void Logger::debug ( std::string message ) const
        {
            log ( "DEBUG:", message );
        }

        void Logger::error ( std::string message ) const
        {
            log ( "ERROR:", message );
        }

        void Logger::info ( std::string message ) const
        {
            log ( "INFO:", message );
        }
    };
};
