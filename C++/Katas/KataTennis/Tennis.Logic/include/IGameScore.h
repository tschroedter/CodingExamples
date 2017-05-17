#pragma once
#include "Scores.h"
#include <string>
#include <memory>

namespace Tennis
{
    namespace Logic
    {
        class IGameScore
        {
        public:
            virtual ~IGameScore () = default;

            virtual std::string to_string () const = 0;
            virtual void won_point () = 0;
            virtual void lost_point () = 0;
            virtual Scores get_score () const = 0;
        };

        typedef std::shared_ptr<IGameScore> IGameScore_Ptr;
    };
};
