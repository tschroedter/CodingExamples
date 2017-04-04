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
                std::string type,
                std::string message ) const;

        public:
            Logger ( std::ostream& out )
                : m_ostream ( out )
            {
            }

            ~Logger ()
            {
            }

            void debug ( std::string message ) const override;
            void error ( std::string message ) const override;
            void info ( std::string message ) const override;
        };
    };
};
