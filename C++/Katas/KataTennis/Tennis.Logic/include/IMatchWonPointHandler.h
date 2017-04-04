#pragma once

namespace Tennis
{
    namespace Logic
    {
        class IMatchWonPointHandler
        {
        public:
            virtual ~IMatchWonPointHandler() = default;

            virtual void won_point(const Player player) = 0;
        };
    };
};
