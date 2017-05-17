#pragma once
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class IScoreBoard
        {
        public:
            virtual ~IScoreBoard () = default;

            virtual void initialize ( 
                const ISets_Ptr sets,
                const IPlayerNameManager_Ptr manager) = 0;
            virtual void print ( std::ostream& out ) const = 0;
            virtual std::string score_for_player_as_string ( const Player player ) const = 0;
        };

        typedef std::shared_ptr<IScoreBoard> IScoreBoard_Ptr;
    };
};
