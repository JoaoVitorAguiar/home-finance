import { api } from "@/services/api"
import type {
    PaginatedTransactions,
    CreateTransactionInput,
} from "@/types/transaction"

export const TransactionsService = {
    async get(page = 1, pageSize = 10): Promise<PaginatedTransactions> {
        const { data } = await api.get<PaginatedTransactions>(
            `/transactions?page=${page}&pageSize=${pageSize}`
        )
        return data
    },

    async create(input: CreateTransactionInput): Promise<void> {
        await api.post("/transactions", input)
    },
}