#pragma once
#include <iostream>
#include "ILogger.h"

namespace Tennis
{
    namespace Logic
    {
        class Logger
                : public ILogger
        {
        private:
            std::ostream& m_ostream;

            void Logger::log (
<<<<<<< HEAD
                std::string type,
                std::string message ) const;

        public:
            Logger ( std::ostream& out )
=======
                const std::string type,
                const std::string message ) const;

        public:
            Logger ( std::ostream& out = std::cout )
>>>>>>> Update from private repository
                : m_ostream ( out )
            {
            }

            ~Logger ()
            {
            }

<<<<<<< HEAD
            void debug ( std::string message ) const override;
            void error ( std::string message ) const override;
            void info ( std::string message ) const override;
=======
            void debug ( const std::string message ) const override;
            void error ( const std::string message ) const override;
            void info ( const std::string message ) const override;
            void warning ( const std::string message ) const override;
>>>>>>> Update from private repository
        };
    };
};
