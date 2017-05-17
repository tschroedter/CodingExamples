#pragma once
#include "Scores.h"
<<<<<<< HEAD
=======
#include <string>
#include <memory>
>>>>>>> Update from private repository

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
<<<<<<< HEAD
=======

        typedef std::shared_ptr<IGameScore> IGameScore_Ptr;
>>>>>>> Update from private repository
    };
};
