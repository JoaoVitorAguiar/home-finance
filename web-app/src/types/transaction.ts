export type TransactionType = "Expense" | "Income"

export type TransactionListItem = {
    id: number
    description: string
    amount: number
    type: TransactionType
    person: {
        id: number
        name: string
    } | null
    category: {
        id: number
        description: string
    } | null
    createdAt: string
}

export type PaginatedTransactions = {
    page: number
    pageSize: number
    totalItems: number
    totalPages: number
    items: TransactionListItem[]
}

export type CreateTransactionInput = {
    description: string
    amount: number
    type: TransactionType
    personId: number
    categoryId: number
}
