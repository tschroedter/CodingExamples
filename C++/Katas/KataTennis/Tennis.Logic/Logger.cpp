#include <string>
#include "include/Logger.h"

namespace Tennis
{
    namespace Logic
    {
        void Logger::log (
<<<<<<< HEAD
            std::string type,
            std::string message ) const
=======
            const std::string type,
            const std::string message ) const
>>>>>>> Update from private repository
        {
            m_ostream << type << " " << message << '\n';
        }

<<<<<<< HEAD
        void Logger::debug ( std::string message ) const
=======
        void Logger::debug ( const std::string message ) const
>>>>>>> Update from private repository
        {
            log ( "DEBUG:", message );
        }

<<<<<<< HEAD
        void Logger::error ( std::string message ) const
=======
        void Logger::error ( const std::string message ) const
>>>>>>> Update from private repository
        {
            log ( "ERROR:", message );
        }

<<<<<<< HEAD
        void Logger::info ( std::string message ) const
        {
            log ( "INFO:", message );
        }
=======
        void Logger::info ( const std::string message ) const
        {
            log ( "INFO:", message );
        }

        void Logger::warning ( const std::string message ) const
        {
            log ( "WARNING:", message );
        }
>>>>>>> Update from private repository
    };
};
