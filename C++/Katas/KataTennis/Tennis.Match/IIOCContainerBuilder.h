#pragma once

#include <Hypodermic/Container.h>
#include <Hypodermic/ContainerBuilder.h>

namespace Tennis
{
    namespace Match
    {
        typedef std::shared_ptr<Hypodermic::Container> Container_Ptr;

        class IIOCContainerBuilder
        {
        public:
            virtual ~IIOCContainerBuilder () = default;

            virtual Container_Ptr build () = 0;
        };
    };
};
