import React, { createContext, useState, useEffect } from 'react';

export const PermisionContext = createContext({});

const PermisionProvider = (props) => {

    const typeOfPermission = ["Add","edit","revoke"]
    return (
        <PermisionContext.Provider
            value={{typeOfPermission}}
        >
            {props.children}
        </PermisionContext.Provider>
    )
}
export default PermisionProvider;