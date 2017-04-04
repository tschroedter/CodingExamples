#pragma once
#pragma once
#include "Player.h"
#include "ISets.h"
#include "IMatchWonPointHandler.h"

namespace Tennis
{
    namespace Logic
    {
        class MatchWonPointHandler
            : public IMatchWonPointHandler
        {
        private:
            ISets* m_sets;

            bool is_tie_break_finsihed() const;
            void create_new_set_and_call_won_point(Player player) const;

        public:
            MatchWonPointHandler(ISets* sets)
                : m_sets(sets)
            {
            }

            ~MatchWonPointHandler()
            {
            }

            void won_point(const Player player) override;
        };
    };
};
