#pragma once
#include <Hypodermic/Container.h>
#include "IIOCContainerBuilder.h"

namespace Tennis
{
    namespace Match
    {
        typedef std::shared_ptr<Hypodermic::Container> Container_Ptr;

        class IOCContainerBuilder
                : public IIOCContainerBuilder
        {
        private:
            static void register_components ( Hypodermic::ContainerBuilder& builder );

        public:
            ~IOCContainerBuilder ()
            {
            }

            Container_Ptr build () override;
        };
    };
};
