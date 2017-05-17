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
                const std::string type,
                const std::string message ) const;

        public:
            Logger ( std::ostream& out = std::cout )
                : m_ostream ( out )
            {
            }

            ~Logger ()
            {
            }

            void debug ( const std::string message ) const override;
            void error ( const std::string message ) const override;
            void info ( const std::string message ) const override;
            void warning ( const std::string message ) const override;
        };
    };
};
